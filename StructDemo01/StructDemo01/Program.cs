// See https://aka.ms/new-console-template for more information

using StructDemo01;


Resolution hdResolution = new Resolution(1920,1080);

/* Do it by myself */
Resolution aaaaa = new Resolution(1000, 1100);
/* Do it by myself */

var cinemaResolution = hdResolution;
cinemaResolution.Width = 2048;
Console.WriteLine($"HD resolution is {hdResolution.Width} px wide and {hdResolution.Height} px height");
Console.WriteLine($"Cinema resolution is {cinemaResolution.Width} px wide and {cinemaResolution.Height} px height");

/* Do it by myself */
Console.WriteLine($"AAAA is {aaaaa.Width} px wide and {aaaaa.Height} px height");
/* Do it by myself */

//VideoMode someVideoMode = new VideoMode();
//Same as
VideoMode someVideoMode = new();

/* Use class and change value would change the whole value */
/* Use struct changevalue will only change the one you re-assign */