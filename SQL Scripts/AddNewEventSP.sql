use GuviCRMSuite
go

alter proc AddNewEvent(@event_id varchar(10), @eventstartdttm datetime, @eventenddttm datetime, @createdby varchar(25), @modifiedby varchar(25),	@goaltitle varchar(25), @goals varchar(1000))
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

