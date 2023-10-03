using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SistemaVentas.DTO;
using SistemaVentas.MODEL;

namespace SistemaVentas.UTILITY
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>();
            #endregion Rol

            #region Menu
            CreateMap<Menu,MenuDTO>();
            #endregion Menu

            #region Usuario 
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                destino.RolDescripcion, opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre));
            #endregion Usuario



        }

    }
}
