namespace CompanySystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        /*------------------------------------------------------------------*/
        private readonly AppDbContext _context;
        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }
        /*------------------------------------------------------------------*/
        public UnitOfWork
            (
                AppDbContext context,
                IProductRepository productRepository,
                ICategoryRepository categoryRepository      
            )
        {
            _context = context;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }
        /*------------------------------------------------------------------*/
        public void Save()
        {
            _context.SaveChanges();
        }
        /*------------------------------------------------------------------*/
    }
}
