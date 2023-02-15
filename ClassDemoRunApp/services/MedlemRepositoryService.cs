using RunLib.model;

namespace ClassDemoRunApp.services
{
    public class MedlemRepositoryService : IMedlemRepositoryService
    {
        /*
         * Repository data
         */
        private readonly List<Medlem> medlemmer = new List<Medlem>(){
            new Medlem("Peter", 1, "11223344", "grøn", 55),
            new Medlem("Per", 2, "22334455", "gul", 51),
            new Medlem("Ivan", 3, "22334466", "rød", 57),
            new Medlem("Vibeke", 4, "55223344", "sort", 70)
        };



        /*
         * CRUD operations
         */

        public Medlem Create(Medlem medlem)
        {
            try
            {
                GetById(medlem.MedlemsId);
                throw new ArgumentException($"Medlem med id {medlem.MedlemsId} findes i forvejen");
            }
            catch (KeyNotFoundException knfe)
            {
                // findes ikke , derfor kan medlem tilføjes

                medlemmer.Add(medlem);
                return medlem;
            }
        }

        public Medlem Delete(int id)
        {
            Medlem fundetMedlem = GetById(id); // throw exception if not found

            medlemmer.Remove(fundetMedlem);
            return fundetMedlem;
        }

        public List<Medlem> GetAll()
        {
            return new List<Medlem>(medlemmer);
        }

        public Medlem GetById(int id)
        {
            foreach (Medlem m in medlemmer)
            {
                if (m.MedlemsId == id)
                {
                    return m;
                }
            }

            throw new KeyNotFoundException($"Medlem med id {id} findes ikke");
        }

        public Medlem Update(int id, Medlem medlem)
        {
            Medlem fundetMedlem = GetById(id); // throw exception if not found

            int ix = medlemmer.IndexOf(fundetMedlem);
            medlemmer[ix] = medlem;
            return medlemmer[ix];
        }
    }
}
