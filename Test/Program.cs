using API.Models;
using Newtonsoft.Json;
using RestSharp;
using Test;


Recipe recipe2 = await Repository.GetRecipe();
int x = 2;
Console.WriteLine(recipe2);
Console.WriteLine("RADIS");

