

using SportacusGen.ApplicationCore.IRepository.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;
using SportacusGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportacusGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IChatRepository ChatRepository {
        get
        {
                this.chatrepository = new ChatRepository ();
                this.chatrepository.setSessionCP (session);
                return this.chatrepository;
        }
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IProductoRepository ProductoRepository {
        get
        {
                this.productorepository = new ProductoRepository ();
                this.productorepository.setSessionCP (session);
                return this.productorepository;
        }
}

public override IMensajeRepository MensajeRepository {
        get
        {
                this.mensajerepository = new MensajeRepository ();
                this.mensajerepository.setSessionCP (session);
                return this.mensajerepository;
        }
}

public override IImagenRepository ImagenRepository {
        get
        {
                this.imagenrepository = new ImagenRepository ();
                this.imagenrepository.setSessionCP (session);
                return this.imagenrepository;
        }
}

public override IFavoritoRepository FavoritoRepository {
        get
        {
                this.favoritorepository = new FavoritoRepository ();
                this.favoritorepository.setSessionCP (session);
                return this.favoritorepository;
        }
}

public override ICompraRepository CompraRepository {
        get
        {
                this.comprarepository = new CompraRepository ();
                this.comprarepository.setSessionCP (session);
                return this.comprarepository;
        }
}

public override IValoracionRepository ValoracionRepository {
        get
        {
                this.valoracionrepository = new ValoracionRepository ();
                this.valoracionrepository.setSessionCP (session);
                return this.valoracionrepository;
        }
}

public override INotificacionRepository NotificacionRepository {
        get
        {
                this.notificacionrepository = new NotificacionRepository ();
                this.notificacionrepository.setSessionCP (session);
                return this.notificacionrepository;
        }
}
}
}

