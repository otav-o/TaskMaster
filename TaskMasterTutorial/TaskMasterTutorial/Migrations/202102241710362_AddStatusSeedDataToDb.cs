﻿namespace TaskMasterTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusSeedDataToDb : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status (Name) VALUES ('To Do');");
            Sql("INSERT INTO Status (Name) VALUES ('In Progress');");
            Sql("INSERT INTO Status (Name) VALUES ('Done');");
        }

        public override void Down()
        {
            // We really should put some delete statemenst in here
        }
    }
}
