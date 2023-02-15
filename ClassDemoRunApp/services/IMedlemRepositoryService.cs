using RunLib.model;

namespace ClassDemoRunApp.services
{
    public interface IMedlemRepositoryService
    {
        public List<Medlem> GetAll();
        public Medlem GetById(int id);
        public Medlem Create(Medlem medlem);
        public Medlem Update(int id, Medlem medlem);
        public Medlem Delete(int id);

    }
}
