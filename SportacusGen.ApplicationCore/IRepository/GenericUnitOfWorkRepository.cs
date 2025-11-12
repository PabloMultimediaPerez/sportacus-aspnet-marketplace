
using System;
using System.Collections.Generic;
using System.Text;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IProductoRepository productorepository;
protected IMensajeRepository mensajerepository;
protected IImagenRepository imagenrepository;
protected IFavoritoRepository favoritorepository;
protected ICompraRepository comprarepository;
protected IValoracionRepository valoracionrepository;
protected INotificacionRepository notificacionrepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IProductoRepository ProductoRepository {
        get;
}
public abstract IMensajeRepository MensajeRepository {
        get;
}
public abstract IImagenRepository ImagenRepository {
        get;
}
public abstract IFavoritoRepository FavoritoRepository {
        get;
}
public abstract ICompraRepository CompraRepository {
        get;
}
public abstract IValoracionRepository ValoracionRepository {
        get;
}
public abstract INotificacionRepository NotificacionRepository {
        get;
}
}
}
