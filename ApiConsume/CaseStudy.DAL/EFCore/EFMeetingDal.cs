using CaseStudy.DAL.Abstract;
using CaseStudy.DAL.Concrete;
using CaseStudy.DAL.Repositories;
using CaseStudy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.DAL.EFCore
{
    public class EFMeetingDal : GenericRepository<Meeting>,IMeetingDal
    {
        public EFMeetingDal(Context context) :base(context)
        {
            
        }
    }
}
