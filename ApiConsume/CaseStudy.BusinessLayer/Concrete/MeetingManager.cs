using CaseStudy.BusinessLayer.Abstract;
using CaseStudy.DAL.Abstract;
using CaseStudy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.BusinessLayer.Concrete
{
    public class MeetingManager : IMeetingService
    {
        private readonly IMeetingDal _meetingDal;

        public MeetingManager(IMeetingDal meetingDal)
        {
            _meetingDal = meetingDal;
        }
        public void TDelete(Meeting t)
        {
            _meetingDal.Delete(t);
        }

        public List<Meeting> TGetAll()
        {
            return _meetingDal.GetAll();
        }

        public Meeting TGetById(int id)
        {
            return _meetingDal.GetById(id);
        }

        public void TInsert(Meeting t)
        {
           _meetingDal.Insert(t);
        }

        public void TUpdate(Meeting t)
        {
           _meetingDal.Update(t);
        }
    }
}
