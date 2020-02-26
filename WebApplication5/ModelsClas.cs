using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Model;

namespace WebApplication5
{
    public class ModelsClas
    {
        ResumeDB db = new ResumeDB();
        public tbl_CV CV { get; set; }
        public tbl_CVPhoto CVPHOTO  {get; set;}
        public tbl_AboutMe AboutMe { get; set; }
        public tbl_AboutMePhoto AboutMePhoto { get; set; }
        public List<tbl_WhatIDo> WhatIDo { get; set; }
        public List<tbl_SkillLeft> SkillLeft { get; set; }
        public List<tbl_SkillRight> SkillRight { get; set; }
        public List<tbl_Education> Educations { get; set; }
        public List<tbl_Work> Works { get; set; }
        public List<tbl_Pricing> Pricings { get; set; }
        public List<tbl_Post> Posts { get; set; }
        public List<tbl_Client> Clients { get; set; }
        public tbl_Contact Contact { get; set; } 
            
    }
}