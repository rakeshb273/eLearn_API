using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearnDataAccess
{
    public class _learners
    {
        eLearnEntities el = new eLearnEntities();
        public List<Learner> getLearners()
        {
            List<Learner> _Learners = new List<Learner>();
            _Learners = el.Learners.ToList();

            return _Learners;
        }
        public List<Learner> getLearners(int id)
        {
            List<Learner> _Learners = new List<Learner>();
            _Learners = el.Learners.Where(x => x.ID == id).ToList();

            return _Learners;
        }
        public void addLearner(Learner learner)
        {
            el.Learners.Add(learner);
            el.SaveChanges();
        }
        public void removeLearner(int id)
        {
            Learner _learner = el.Learners.Where(x => x.ID == id).FirstOrDefault();
            _learner.isActive = false;
            el.SaveChanges();
        }
    }
}
