using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mca
{
    public class Service
    {
        public List<NavModel> ReadFile(string UrlPath)
        {

            List<NavModel> navModels = new List<NavModel>();
            string[] lines = File.ReadAllLines(UrlPath);

            foreach (var line in lines.Skip(1))
            {

                var row = line.Split(';');

                bool check = int.TryParse(row[2], out int parentId);

                var navModel = new NavModel
                {
                    Id = Convert.ToInt32(row[0]),
                    MenuName = row[1],
                    ParentId = parentId,
                    IsHidden = Convert.ToBoolean(row[3]),
                    LinkUrl = row[4]
                };

                navModels.Add(navModel);
            }
            return navModels.OrderBy(x => x.MenuName).ToList();
        }

        public List<NavModel> AllList(List<NavModel> navModels)
        {
            int level = 1;

            return navModels
                    .Where(c => c.ParentId == 0)
                    .Select(c => new NavModel
                    {
                        Id = c.Id,
                        MenuName = c.MenuName,
                        ParentId = c.ParentId,
                        IsHidden = c.IsHidden,
                        LinkUrl = c.LinkUrl,
                        Level = level,
                        Children = GetChildren(navModels, c.Id, level + 1)
                    })
                    .ToList();

        }

        public static List<NavModel> GetChildren(List<NavModel> navModels, int parentId, int level)
        {


            return navModels
                    .Where(c => c.ParentId == parentId)
                    .Select(c => new NavModel
                    {
                        Id = c.Id,
                        MenuName = c.MenuName,
                        ParentId = c.ParentId,
                        IsHidden = c.IsHidden,
                        LinkUrl = c.LinkUrl,
                        Level = level,
                        Children = GetChildren(navModels, c.Id, level + 1)
                    })
                    .ToList();

        }

        public  void OutPut(List<NavModel> navModels)
        {

            foreach (var item in navModels)
            {
                if (item.IsHidden == false)
                {
                   
                    StringBuilder builder = new StringBuilder(".");
                    int countLevel = item.Level;
                    if (countLevel > 1)
                    {
                        for (int i = 0; i < countLevel - 1; i++)
                        {
                            builder.Append("...");
                        }

                        Console.WriteLine(builder + $"{item.MenuName}");
                        OutPut(item.Children);
                    }
                    else
                    {
                        Console.WriteLine(builder + $"{item.MenuName}");
                        OutPut(item.Children);

                    }
                }
            }
        }
    }
}
