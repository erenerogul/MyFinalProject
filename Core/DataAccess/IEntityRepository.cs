using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Entity yani varlıkların repositorysi diyerek biz generic tipte bir koşullar yazacağız böylelikle category ve product alanları
    //için teker teker uğraşmak yerine tek interface ile halletmiş olacağız 
    //Verdiğimiz türe göre tür alan bir interface yaptık Generic kullanmış olduk kısacası 

    //Generic constraint -generic kısıt 
    //Biz burada T yi kısıtlıyoruz birisi gelip mesela int yazamasında diye bu yüzden 
    //Where T: Class dediğimizde sadece referans tipleri ile kısıtlamış oluyoruz 
    //Class : referans tip
    //Daha sonra IEntity diyerek biz sadece Entities deki concrete içerisinde bulunan classlara göre sınırlandırdık bu classların ortak
    //noktası IEntitye extends olmasından dolayı Ama başka bir yerde çağırım yaparken IEntity de olabilir
    //new() newlenebilir olmalı IEntity newlenebilir değildir yani soyut bir nesne olduğundan dolayı olmuyor 

    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>  filter = null);
        //Expression bize linq ile filtreler yapabilmemizi sağlıyor 
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
