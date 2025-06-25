using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Bombones2025.DatosSql.Repositorios
{
    public class FrutoSecoRepositorio : IFrutoSecoRepositorio
    {
        private readonly BombonesDbContext _dbContext;

        public FrutoSecoRepositorio(BombonesDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Agregar(FrutoSeco frutoSeco)
        {
            _dbContext.FrutosSecos.Add(frutoSeco);
            _dbContext.SaveChanges();
        }

        public void Borrar(int rellenoId)
        {
            var rellenoInDb = _dbContext.FrutosSecos.Find(rellenoId);
            if (rellenoInDb != null)
            {
                _dbContext.FrutosSecos.Remove(rellenoInDb);
                _dbContext.SaveChanges();
            }
        }

        public void Editar(FrutoSeco frutoSeco)
        {
            _dbContext.FrutosSecos.Update(frutoSeco);
            _dbContext.SaveChanges();
        }

        public bool Existe(FrutoSeco frutoSeco)
        {
            return frutoSeco.FrutoSecoId == 0
                ? _dbContext.FrutosSecos.Any(p => p.Descripcion == frutoSeco.Descripcion)
                : _dbContext.FrutosSecos.Any(p => p.Descripcion == frutoSeco.Descripcion
                    && p.FrutoSecoId == frutoSeco.FrutoSecoId);
        }

        public List<FrutoSeco> GetLista(string? textoFiltro = null)
        {
            return textoFiltro is null
                ? _dbContext.FrutosSecos.AsNoTracking().ToList()
                : _dbContext.FrutosSecos.AsNoTracking()
                .Where(p => p.Descripcion.StartsWith(textoFiltro))
                .ToList();
        }
        public int GetCantidad() => _dbContext.FrutosSecos.Count();

    }
}
