using System.Collections.Generic;

namespace SupermarketData
{
	public class Furnizor
	{
		public Furnizor(int id, string nume, List<ProdusOferta> produseOferta)
		{
			Id = id;
			Nume = nume;
			ProduseOferta = produseOferta;
		}

		public int Id { get; set; }
		public string Nume { get; set; }
		public List<ProdusOferta> ProduseOferta { get; set; }
	}
}