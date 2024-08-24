using BookStore.Models;

namespace BookStore.Repository
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext context;
        public PublisherService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Publisher model)
        {
            try
            {
                context.Publisher.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Publisher.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Publisher FindById(int id)
        {
            return context.Publisher.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return context.Publisher.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                context.Publisher.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
