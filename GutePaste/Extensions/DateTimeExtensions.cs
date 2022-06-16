namespace GutePaste.Extensions
{
  public static class DateTimeExtensions
  {
    public static long ToUnixTimeStamp(this DateTime dtime)
    {
      return (long)(dtime - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
    }
    public static DateTime FromUnixTimeStamp(long unixTimeStamp)
    {
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
      return (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTimeStamp);
    }
  }
}
