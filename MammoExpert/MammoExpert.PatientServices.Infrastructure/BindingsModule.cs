using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using MammoExpert.PatientServices.DB;

namespace MammoExpert.PatientServices.Infrastructure
{
    public class BindingsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PatientContext>().ToSelf().InSingletonScope();
        }
    }
}
