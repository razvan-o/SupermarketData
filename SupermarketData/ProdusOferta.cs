namespace SupermarketData
{
	public class ProdusOferta
	{
		public ProdusOferta()
		{
		}

		public ProdusOferta(int sku, string nume, decimal pret, string categorie, long bucatiComandaMinima)
		{
			Sku = sku;
			Nume = nume;
			Pret = pret;
			Categorie = categorie;
			BucatiComandaMinima = bucatiComandaMinima;
		}

		public int Sku { get; set; }
		public string Nume { get; set; }
		public decimal Pret { get; set; }
		public string Categorie { get; set; }
		public long BucatiComandaMinima { get; set; }
	}
}