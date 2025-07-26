using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Bombones2025.DatosSql.Repositorios
{
    public class ChocolateRepositorio : IChocolateRepositorio
    {
        private readonly BombonesDbContext _dbContext;

        public ChocolateRepositorio(BombonesDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Agregar(Chocolate chocolate)
        {
            _dbContext.Chocolates.Add(chocolate);
            _dbContext.SaveChanges();
        }

        public void Borrar(int chocolateId)
        {
            var chocolateInDb = _dbContext.Chocolates.Find(chocolateId);
            if (chocolateInDb != null)
            {
                _dbContext.Chocolates.Remove(chocolateInDb);
                _dbContext.SaveChanges();
            }
        }

        public void Editar(Chocolate chocolate)
        {
            var chocoInDb = ObtenerPorId(chocolate.ChocolateId);
            if (chocoInDb == null) return;
            chocoInDb.Descripcion=chocolate.Descripcion;
            _dbContext.SaveChanges();
        }

        public bool Existe(Chocolate chocolate)
        {
            return chocolate.ChocolateId == 0
                ? _dbContext.Chocolates.Any(p => p.Descripcion == chocolate.Descripcion)
                : _dbContext.Chocolates.Any(p => p.Descripcion == chocolate.Descripcion
                    && p.ChocolateId == chocolate.ChocolateId);
        }

        public List<Chocolate> ObtenerLista(string? textoFiltro = null)
        {
            return textoFiltro is null
                ? _dbContext.Chocolates.AsNoTracking().ToList()
                : _dbContext.Chocolates.AsNoTracking()
                .Where(p => p.Descripcion.StartsWith(textoFiltro))
                .ToList();
        }
        public int ObtenerCantidad() => _dbContext.Chocolates.Count();

        public Chocolate? ObtenerPorId(int id)
        {
            return _dbContext.Chocolates.FirstOrDefault(c=>c.ChocolateId==id);
        }
    }
}
