using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        // Invocataion : busines method 
        //Virtual metodlar senin onu ezmeni bekleyen metodlar anlamına geliyor 
        //Biz aspect yazdığımız zaman o aspect nerede çalışsın istiyorsak gidip onun ilgili metodlarını eziyoruz
        //Aspect aslında bu metodları temel alan hangisi istiyorsan o zaman çalışssın diyen bi sistem 
        //Kısacası bizim bussines katmanında yazmış olduğumuz try cacthci önce çalışssın hata verdiğinde çalışssın gibi generic ve temel bir yapıya dökmüş olduk
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
