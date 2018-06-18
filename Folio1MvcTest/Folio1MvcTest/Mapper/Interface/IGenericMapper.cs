using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Folio1MvcTest.Mapper.Interface
{
    public interface IGenericMapper<TEntity, TViewModel>
    {
        TViewModel ToViewModel(TEntity entity);
        TViewModel ToViewModel(List<TEntity> entity);
        TEntity ToEntity(TViewModel viewModel);
        List<TEntity> ToEntity(List<TViewModel> viewModel);


    }
}