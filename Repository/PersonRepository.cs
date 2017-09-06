using Model;


namespace Repository
{
    public class PersonRepository :Repository<Person>, IPersonRepository
    {
        public PersonRepository(CVContext context) : base(context)
        {
           
        }
        
       
    }
}
