using BCrud.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public static class DatabaseSeeding
    {
//        public static void Seed()
//        {
//            using (var context = new DatabaseContext())
//            {
//                if (context.Trades.Any())
//                {
//                    return;
//                }


//                for (int i = 100; i <= 120; i++)
//                {
//                    context.Trades.Add(new BCrud.Domain.Entities.Trade(Guid.NewGuid(), $"Trade {i.ToString()}"));
//                }
//                context.SaveChanges();

//                // Seeding using raw sql because of the issue with foreign key exception
//                // this is temporary will fix later.
//                context.Database.ExecuteSqlCommand(@"
//                  SELECT *, ROW_NUMBER() OVER(ORDER BY Id) AS RN
//                  INTO #Trades
//                  FROM Trades

//                  DECLARE @Counter INT = 1
//                  DECLARE @Total INT = (SELECT COUNT(*) FROM #Trades)
//                  WHILE @Counter <= @Total
//                  BEGIN
//	                DECLARE @TradeId VARCHAR(MAX)  = (SELECT Id FROM #Trades WHERE RN = @Counter)
//	                INSERT INTO TradeLevels (Id, Title, TradeId)
//	                VALUES (NEWID(), 'Trade Level '+CAST(@Counter AS VARCHAR(MAX)), @TradeId)
//	                SET @Counter = @Counter + 1
//                  END

//                ");



//                context.Database.ExecuteSqlCommand(@"
    
//                INSERT INTO [dbo].[Syllabi]
//                           ([Id]
//                           ,[Name]
//                           ,[TradeId]
//                           ,[TradeLevelId]
//                           ,[Languages]
//                           ,[SyllabusFilename]
//                           ,[SyllabusUrl]
//                           ,[TestPlanFilename]
//                           ,[TestPlanUrl]
//                           ,[DevelopmentOfficer]
//                           ,[Manager]
//                           ,[ActiveDate])
  
//                SELECT TOP(2) NEWID()
//	                , 'Name' + CAST(ROW_NUMBER() OVER(ORDER BY T.ID) AS VARCHAR(MAX))
//	                , T.Id AS TradeID
//	                , TV.id AS TradeLevelID
//	                , 'EN'
//                     , 'SampleSyllabusUrl'+ CAST(ROW_NUMBER() OVER(ORDER BY T.ID) AS VARCHAR(MAX)) +'.pdf'                    
//                    , 'https://localhost:44333/files/' + 'SampleSyllabusUrl'+ CAST(ROW_NUMBER() OVER(ORDER BY T.ID) AS VARCHAR(MAX)) +'.pdf'
//	               , 'SampleTestPlanUrl'+ CAST(ROW_NUMBER() OVER(ORDER BY T.ID) AS VARCHAR(MAX)) +'.docx'
//                    , 'https://localhost:44333/files/'+	'SampleTestPlanUrl'+ CAST(ROW_NUMBER() OVER(ORDER BY T.ID) AS VARCHAR(MAX)) +'.docx'                
//	                , 'Development Officer Name' + CAST(ROW_NUMBER() OVER(ORDER BY T.ID) AS VARCHAR(MAX)) 
//	                , 'Manager name' + CAST(ROW_NUMBER() OVER(ORDER BY T.ID) AS VARCHAR(MAX))
//	                , GETDATE()	
//                FROM Trades T
//                INNER JOIN TradeLevels TV ON T.Id = TV.TradeId


//");
//            }
//        }
    }
}
