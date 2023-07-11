using Dapper;
using Nest;
using spotApi.Models;
using spotApi.Repo.Interface;
using System.Data;

namespace spotApi.Repo.Implements
{


    public class ProductReposiory : IBaseRepository<Product>
    {
        private readonly IDapperContext _context;

        public ProductReposiory(IDapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();

        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {

                var sql = @"
                            SELECT p.*, t.*, s.*
                            FROM product p
                            LEFT JOIN tag t ON p.id = t.product_id
                            LEFT JOIN supplier s ON p.supplier_id = s.supplier_id";


                var productDictionary = new Dictionary<int, Product>();

                await _context.Db.QueryAsync<Product, Tag, Supplier, Product>(
                    sql,
                    (product, tag, supplier) =>
                    {
                        if (!productDictionary.TryGetValue(product.id, out var existingProduct))
                        {
                            existingProduct = product;
                            existingProduct.Tags = new List<Tag>();
                            productDictionary.Add(existingProduct.id, existingProduct);
                        }

                        existingProduct.Tags.Add(tag);
                        existingProduct.Suppliers = supplier;
                        return existingProduct;
                    },
                    splitOn: "id, product_id, supplier_id"
                );


                var products = productDictionary.Values;

                return products;
        }

        public async Task<Product> GetById(int id)
        {
            
                var sql = @"
            SELECT p.*, t.*, s.*
            FROM product p
            LEFT JOIN tag t ON p.id = t.product_id
            LEFT JOIN supplier s ON p.supplier_id = s.supplier_id
            WHERE p.id = @ProductId";

                var productDictionary = new Dictionary<int, Product>();

            var product = await _context.Db.QueryAsync<Product, Tag, Supplier, Product>(
                sql,
                (p, tag, supplier) =>
                {
                    if (!productDictionary.TryGetValue(p.id, out var existingProduct))
                    {
                        existingProduct = p;
                        existingProduct.Tags = new List<Tag>();
                        productDictionary.Add(existingProduct.id, existingProduct);
                    }

                    existingProduct.Tags.Add(tag);
                    existingProduct.Suppliers = supplier;
                    return existingProduct;
                },
                new { ProductId = id },
                splitOn: "id, product_id, supplier_id"
            );

                return product.FirstOrDefault();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
