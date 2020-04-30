namespace SupermarketData
{
	public class Produs
	{
		public int Sku { get; set; }
		public string Nume { get; set; }
		public decimal Pret { get; set; }
		public string Categorie { get; set; }
		public string Descriere { get; set; }
		public long Stoc { get; set; }
		public long StocMinim { get; set; }
		public long StocMaxim { get; set; }
	}
}