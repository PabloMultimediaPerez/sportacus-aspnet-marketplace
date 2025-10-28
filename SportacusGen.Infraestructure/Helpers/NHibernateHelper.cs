using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

using SportacusGen.Infraestructure.EN.Sportacus;


namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public static class NHibernateHelper
{
private static ISessionFactory _sessionFactory;

private static ISessionFactory SessionFactory
{
        get
        {
                if (_sessionFactory == null) {
                        var configuration = new Configuration ();
                        configuration.Configure ();
                        configuration.AddAssembly (typeof(ChatNH).Assembly);
                        _sessionFactory = configuration.BuildSessionFactory ();
                }

                return _sessionFactory;
        }
}

public static ISession OpenSession ()
{
        return SessionFactory.OpenSession ();
}
}
}
