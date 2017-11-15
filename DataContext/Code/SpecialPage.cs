using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext.Repository;
using DataContext.Interface;

namespace DataContext.EDM
{
    public partial class SpecialPage : LanguageRepository<SpecialPage>, ITrackeble, IStatable, IPrimary<long>, ILanguage, IOriginal
    {

    }
}
