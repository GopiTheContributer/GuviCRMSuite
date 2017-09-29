use GuviCRMSuite
go
-- add new event
create proc AddNewEvent(@event_id varchar(10), @eventstartdttm datetime, @eventenddttm datetime, @createdby varchar(25), @modifiedby varchar(25),	@goaltitle varchar(25), @goals varchar(1000))
as begin

begin try 
	begin tran Addevent;
		declare @recentId int;

		insert into goal(goaltitle, goals, createdby, modifiedby) 
		values(@goaltitle, @goals, @createdby, @modifiedby)

		set @recentId = scope_identity()

		insert into scheduler(event_id, goalid, eventstartdttm, eventenddttm, createdby, modifiedby)
		values(@event_id, @recentId , @eventstartdttm, @eventenddttm, @createdby, @modifiedby)
	commit tran Addevent;
end try 

begin catch
rollback tran addevent
end catch

end

go 

--soft delete the event
create proc DeleteEvent (@goalid varchar(10))
as begin 

begin try 
	begin tran SoftDeleteEvent;
			
		update Scheduler set [status] = 'D' where GoalId = @goalid;
		update Goal set [status] = 'D' where Goal_id = @goalid;
		
	commit tran SoftDeleteEvent;
end try 

begin catch
	rollback tran SoftDeleteEvent
end catch

end

go 

---- update the events
create proc updateevent(@eventstartdttm datetime, @eventenddttm datetime, @modifiedby varchar(25),	@goaltitle varchar(25), @goals varchar(1000), @goalid varchar(10))
as begin

begin try 
	begin tran UpdateEvent;
			
		update Scheduler set EventstartDTTM = @eventstartdttm, EventEndDTTM = @eventenddttm, modifiedby = @modifiedby
		 where GoalId = @goalid;
		update Goal set GoalTitle = @goaltitle, Goals = @goals, Modifiedby = @modifiedby where Goal_id = @goalid;
		
	commit tran UpdateEvent;
end try 

begin catch
	rollback tran UpdateEvent
end catch


end

