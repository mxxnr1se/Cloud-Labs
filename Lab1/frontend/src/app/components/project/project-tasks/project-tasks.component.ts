import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { switchMap } from 'rxjs/operators';
import { Task } from 'src/app/shared/task/task.model';
import { TaskService } from 'src/app/shared/task/task.service';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-project-tasks',
  templateUrl: './project-tasks.component.html',
  styles: [
  ]
})
export class ProjectTasksComponent implements OnInit, OnDestroy {
  
  serach:string;
  id: number;
  constructor(private route: ActivatedRoute, public service:TaskService, 
    public userService:UserService, private toastr:ToastrService) { }
  
  ngOnDestroy(): void {
    if (this.service.list != undefined) this.service.list.length = 0;
    this.service.percentageOfCompletion = 0;
    if (this.service.listOfProjectUsers != undefined) this.service.listOfProjectUsers.length = 0;
  }

  ngOnInit(): void {
    this.route.paramMap.pipe(switchMap(params => params.getAll('id')))
        .subscribe(data=> {this.id = +data });
    if (this.userService.role === 'Manager')
        this.service.refreshListManager(this.id);
    else this.service.refreshListUser(this.id);
    
    this.serach ='';
  }

  onDelete(task: Task){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteTask(task.id)
      .subscribe(
       res=>{
         if (this.userService.role === 'Manager')
          this.service.refreshListManager(this.id);
         else this.service.refreshListUser(this.id);
         this.service.formData = new Task();
         this.toastr.error("Deleted successfully", `Task '${task.name}' deleted`)
       },
       err => {
        this.toastr.error(err.error, "Task wasn't deleted")
        }
      )
    }
  }

  populateForm(selectedRecord:Task){
    this.service.formData =  Object.assign({}, selectedRecord);
  }
}