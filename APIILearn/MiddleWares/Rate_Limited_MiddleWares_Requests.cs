namespace APIILearn.MiddleWares
{
    public class Rate_Limited_MiddleWares_Requests          // Make At Most 5 Requests on a Server 
    {
        private readonly RequestDelegate nextreq;
        private static int counter = 0;
        private static DateTime lastTimeReq = DateTime.Now;

        public Rate_Limited_MiddleWares_Requests(RequestDelegate _nextreq)
        {
            nextreq = _nextreq;
        }
        public async Task Invoke(HttpContext context)         // put the mouse in any word and read its notes :)
        {
            counter++;

            if(DateTime.Now.Subtract(lastTimeReq).Seconds > 10)
            {
                counter = 1;
                lastTimeReq = DateTime.Now;

                await nextreq(context);
            }
            else
            {
                if(counter > 5)
                {
                    lastTimeReq = DateTime.Now;
                    await context.Response.WriteAsync("Rate Limited Exceeded");
                }
                else
                {
                    lastTimeReq = DateTime.Now;
                    await nextreq(context);
                }
            }
        }
    }
}
