namespace TinyCrm.Core.Model.Options
{
    public  class AddProductOptions
    {
        /// <summary>
        /// 
        /// </summary>
       public int Id { get; set;}

        /// <summary>
        /// 
        /// </summary>
       public  string Name { get; set;}

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set;}

        /// <summary>
        /// 
        /// </summary>
        public ProductCategory Category { get; set;}
    }
}
