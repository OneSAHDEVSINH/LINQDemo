using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LINQDemo.BAL;
using LINQDemo.DAL;

namespace LINQDemo
{
    public partial class Demo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if(!IsPostBack)
            {
                ddlCity.DataSource = new CityProvider().Cities;
                ddlCity.DataTextField = "Name";
                ddlCity.DataValueField = "CityId";
                ddlCity.DataBind();

                ListItem item = new ListItem()
                { Text = "All", Value = "0"};
                ddlCity.Items.Insert(0, item);

                gvPerson.DataSource = new PersonProvider().Persons;
                gvPerson.DataBind();
            }
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = Convert.ToInt32(ddlCity.SelectedValue);
            List<City> cities = new CityProvider().Cities;
            List<Person> persons = new PersonProvider().Persons;
            if (cityId == 0)
            {
                var result = from per in persons select per;
                gvPerson.DataSource = result;
                gvPerson.DataBind();
            }
            else
            {
                var filter = from per in persons 
                             where per.CityId == cityId
                             join ct in cities
                             on per.CityId equals ct.CityId
                             select new 
                             { 
                                 Id = per.PersonId, 
                                 Person = per.Name, 
                                 Age = per.Age, 
                                 City = ct.Name
                             };
                gvPerson.DataSource = filter;
                gvPerson.DataBind();
                
            }
        }

        protected void btnAge_Click(object sender, EventArgs e)
        {
            List<Person> persons = new PersonProvider().Persons;
            string value = txtAge.Text;
            int age = 0;
            char opr = value[0];
            if (value.Length > 1)
            {
                age = Convert.ToInt16(value.Substring(1));
            }
            switch (opr)
            {
                case '=':
                    var filter = from per in persons
                                 where per.Age == age
                                 select new
                                 {
                                     PersonId = per.PersonId,
                                     Name = per.Name,
                                     Age = per.Age,
                                 };
                    gvPerson.DataSource = filter;
                    gvPerson.DataBind();
                    break;
                case '>':
                    gvPerson.DataSource = from per in persons
                                 where per.Age > age
                                 select new
                                 {
                                     PersonId = per.PersonId,
                                     Name = per.Name,
                                     Age = per.Age,
                                 };
                    gvPerson.DataBind();
                    break;
                case '<':
                    gvPerson.DataSource = from per in persons
                                 where per.Age < age
                                 select new
                                 {
                                     PersonId = per.PersonId,
                                     Name = per.Name,
                                     Age = per.Age,
                                 };
                    gvPerson.DataBind();
                    break;
                case '.':
                    gvPerson.DataSource = from per in persons select per;
                    gvPerson.DataBind();
                    break;
            }
        }

        protected void ddlOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt16(ddlOrderBy.SelectedValue);
            List<Person> persons = new PersonProvider().Persons;
            var query = (from p in persons  select p).AsQueryable();

            switch(value)
            {
                case 0:
                    gvPerson.DataSource = query;
                    gvPerson.DataBind(); 
                    break;
                    
                case 1:
                    gvPerson.DataSource = query.OrderBy(each=>each.Name);
                    gvPerson.DataBind(); 
                    break;
                    
                case 2:
                    gvPerson.DataSource = from p in query orderby p.Age descending select p;
                    gvPerson.DataBind(); 
                    break;
            }
        }

        protected void ddlAggregate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string operation = ddlAggregate.SelectedValue;
            List<Person> persons = new PersonProvider().Persons;
            int age = 0;
            switch (operation)
            {
                case "1":
                    age = persons.Min(each => each.Age);
                    break;
                case "2":
                    age = persons.Max(each => each.Age);
                    break;
                case "3":
                    age = Convert.ToInt32(persons.Average(each => each.Age));
                    break;
                case "4":
                    age = persons.Sum(each => each.Age);
                    break;
            }
            gvPerson.DataSource = from p in persons where p.Age == age select p;
            Person per = (from p in persons where p.Age == age select p).FirstOrDefault();
            if (per != null)
                Response.Write(per.Name);
            else
                Response.Write("Empty");
            gvPerson.DataBind();

        }
    }
}