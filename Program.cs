using System.Collections.Generic;
using Pulumi;
using DigitalOcean = Pulumi.DigitalOcean;

return await Deployment.RunAsync(() =>
{
   var staticSite = new DigitalOcean.App("phrases-generator-app", new()
   {
      Spec = new DigitalOcean.Inputs.AppSpecArgs
      {
         Name = "phrases-generator-app",
         Region = "nyc3",
         StaticSites = new[]
         {
            new DigitalOcean.Inputs.AppSpecStaticSiteArgs
            {
               BuildCommand = "npm run build",
               Git = new DigitalOcean.Inputs.AppSpecStaticSiteGitArgs
               {
                  Branch = "main",
                  RepoCloneUrl = "https://github.com/SamuelMunoz/phrases-generator.git"
               },
               Name = "phrases-generator",
               OutputDir = "/dist"
            }
         }
      }
   });

   // Export outputs here
   return new Dictionary<string, object?>
   {
      ["url"] = staticSite.LiveUrl
   };
});
