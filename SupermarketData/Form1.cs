using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace SupermarketData
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private XmlDocument LoadXML(string fileName)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(fileName);

			return doc;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void loadFileButton_Click(object sender, EventArgs e)
		{
			// Get file name from input box and deduce if it is a XML or a JSON 
			string fileName = this.fileNameInput.Text;
			string extension = GetFileExtension(fileName);
			if (extension == ".xml")
			{
				//Handle XML flow
				ProcessXMLFile(fileName);
			}
			else if (extension == ".json")
			{
				//Handle JSON flow
				ProcessJSONFile(fileName);
			}

		}

		private void ProcessJSONFile(string fileName)
		{
			string inputJSON = File.ReadAllText(fileName);

			webBrowser1.DocumentText = inputJSON;
		}

		private string GetFileExtension(string fileName)
		{
			try
			{
				var extension = fileName.Substring(fileName.LastIndexOf("."));
				if (extension != ".xml" && extension != ".json")
				{
					//Show error and reset fileNameInput text
					MessageBox.Show("The file format must be either .xml or .json");
					this.fileNameInput.Text = string.Empty;
					this.fileNameInput.Focus();
				}

				return extension;
			}
			catch
			{
				//Show error and reset fileNameInput text
				MessageBox.Show("Please specify file format.");
				this.fileNameInput.Text = string.Empty;
				this.fileNameInput.Focus();

				return default;
			}
		}

		private void ProcessXMLFile(string fileName)
		{
			//Incarc fisierul
			try
			{
				var doc = LoadXML(fileName);

				//Extrag furnizorii
				var furnizori = GetFurnizoriFromXML(doc.GetElementsByTagName("furnizori")[0]);
				//Extrag produsele
				var produse = GetProduseFromXML(doc.GetElementsByTagName("produse")[0]);

				var simpleParseString = GenerateSimpleParseString(furnizori, produse);

				webBrowser1.DocumentText = simpleParseString;
			}
			catch
			{
				//Show error and reset fileNameInput text
				MessageBox.Show("Input file specified could not be found or is badly formatted");
				this.fileNameInput.Text = string.Empty;
				this.fileNameInput.Focus();
			}
		}

		private string GenerateSimpleParseString(List<Furnizor> furnizori, List<Produs> produse)
		{
			//Generez stringul care va fi afisat la parsarea simpla a fisierului XML
			var sb = new StringBuilder();

			sb.Append("Supermarket <br><br>");

			//construiesc sectiunea de furnizori
			sb.Append("Furnizori <br>");
			foreach(var furnizor in furnizori)
			{
				sb.Append(furnizor.Nume + "   SKU:" + furnizor.Id + "Produse-Oferta: <br>");
				foreach(var produsOferta in furnizor.ProduseOferta)
				{
					sb.Append(produsOferta.Nume + ": " + produsOferta.Pret + " lei" + " comanda minima:" + produsOferta.BucatiComandaMinima + ";<br>");
				}
				sb.Append("<br>");
			}

			//construiesc sectiunea de produse
			sb.Append("<br><br> Produse <br>");
			foreach (var produs in produse)
			{
				sb.Append(produs.Nume + "___SKU:" + produs.Sku + "<br>pret:" + produs.Pret + "lei" + " <br>stoc:" + produs.Stoc+ "<br><br>");
				
			}
			return sb.ToString();
		}

		private List<Produs> GetProduseFromXML(XmlNode produseXMLNode)
		{
			var produse = new List<Produs>();

			foreach (XmlNode produseXML in produseXMLNode.ChildNodes)
			{
				var productProperties = produseXML.ChildNodes;

				var produs = new Produs()
				{
					Sku = int.Parse(produseXML.Attributes.GetNamedItem("sku").InnerText)
				};

				for (int i = 0; i < productProperties.Count; i++)
				{
					var property = productProperties.Item(i);
					if (property.Name == "nume")
						produs.Nume = productProperties.Item(i).InnerText.Substring(1).TrimEnd('"');
					else if (property.Name == "pret")
						produs.Pret = decimal.Parse(productProperties.Item(i).InnerText);
					else if (property.Name == "categorie")
						produs.Categorie = productProperties.Item(i).InnerText.Substring(1).TrimEnd('"');
					else if (property.Name == "descriere")
						produs.Descriere = productProperties.Item(i).InnerText.Substring(1).TrimEnd('"');
					else if (property.Name == "stoc")
						produs.Stoc = long.Parse(productProperties.Item(i).InnerText);
					else if (property.Name == "stoc_minim")
						produs.StocMinim = long.Parse(productProperties.Item(i).InnerText);
					else if (property.Name == "stoc_maxim")
						produs.StocMaxim = long.Parse(productProperties.Item(i).InnerText);
				}

				produse.Add(produs);
			}

			return produse;
		}

		private List<Furnizor> GetFurnizoriFromXML(XmlNode furnizoriXMLNode)
		{
			var furnizori = new List<Furnizor>();

			//pt fiecare furnizor din XML construiesc o instanta a clasei Furnizor si o adaug in lista
			foreach (XmlNode furnizorXML in furnizoriXMLNode.ChildNodes)
			{
				var nume = furnizorXML.Attributes.GetNamedItem("nume").InnerText;
				var id = int.Parse(furnizorXML.Attributes.GetNamedItem("id").InnerText);

				//Extrag lista de oferte de produse pentru fiecare furnizor
				var oferteProdus = GetOferteProdusFromFurnizorXML(furnizorXML);

				furnizori.Add(new Furnizor(id, nume, oferteProdus));
			}

			return furnizori;
		}

		private List<ProdusOferta> GetOferteProdusFromFurnizorXML(XmlNode furnizorXML)
		{
			var produseOferta = new List<ProdusOferta>();
			//Pentru fiecare element din lista de produse-oferta, creez o instanta a clase ProdusOferta si o adaug in lista
			var produseOfertaXMLNode = furnizorXML.ChildNodes[0];
			foreach (XmlNode produsOfertaXML in produseOfertaXMLNode)
			{
				var produsOferta = new ProdusOferta()
				{
					Sku = int.Parse(produsOfertaXML.Attributes.GetNamedItem("sku").InnerText)
				};

				var productProperties = produsOfertaXML.ChildNodes;
				for (int i = 0; i < productProperties.Count; i++)
				{
					var property = productProperties.Item(i);
					if (property.Name == "nume")
						produsOferta.Nume = productProperties.Item(i).InnerText.Substring(1).TrimEnd('"');
					else if (property.Name == "pret")
						produsOferta.Pret = decimal.Parse(productProperties.Item(i).InnerText);
					else if (property.Name == "categorie")
						produsOferta.Categorie = productProperties.Item(i).InnerText.Substring(1).TrimEnd('"');
					else if (property.Name == "bucati_comanda_minima")
						produsOferta.BucatiComandaMinima = long.Parse(productProperties.Item(i).InnerText);
				}

				produseOferta.Add(produsOferta);
			}

			//returnez lista populata cu produse-oferta
			return produseOferta;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void beautifulXMLParse_Click(object sender, EventArgs e)
		{
			//Parsez fisierul
			string fileName = this.fileNameInput.Text;
			string extension = GetFileExtension(fileName);
			if (extension == ".xml")
			{

				// Generez o pagina HTML din XML folosind fisierul XSL creat in prealabil
				string inputXml = File.ReadAllText(fileName).Replace("\r", "").Replace("\n", "").Replace("\t", "");
				string xsltString = File.ReadAllText("SupermarketOlariuRazvan.xsl").Replace("\r", "").Replace("\n", "").Replace("\t", "");
				XslCompiledTransform transform = new XslCompiledTransform();
				using (XmlReader reader = XmlReader.Create(new StringReader(xsltString)))
				{
					transform.Load(reader);
				}
				StringWriter results = new StringWriter();
				using (XmlReader reader = XmlReader.Create(new StringReader(inputXml)))
				{
					transform.Transform(reader, null, results);
				}

				// Afisez pagina HTML generata
				webBrowser1.DocumentText = results.ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
			}

			else
			{
				//Show error and reset fileNameInput text
				MessageBox.Show("Input file needs to be XML");
				this.fileNameInput.Text = string.Empty;
				this.fileNameInput.Focus();
			}
		}

		private void linkedinPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Specify that the link was visited.
			this.linkedinPage.LinkVisited = true;

			// Navigate to a URL.
			System.Diagnostics.Process.Start("https://www.linkedin.com/in/razvan-olariu-bb23a8150/");
		}

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

	}
}
