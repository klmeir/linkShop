namespace Catalog.Domain.Entities
{
    public class Product : DomainEntity
    {                
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public Guid ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }        
        public int AvailableStock { get; set; }
    }
}
