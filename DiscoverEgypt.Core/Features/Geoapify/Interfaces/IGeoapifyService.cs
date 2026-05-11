using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverEgypt.Core.Features.Geoapify.Interfaces
{
    public interface IGeoapifyService
    {
        Task ImportPlacesAsync();
    }
}
