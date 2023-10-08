import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { switchMap } from 'rxjs/operators';
import { Task } from 'src/app/shared/task/task.model';
import { TaskService } from 'src/app/shared/task/task.service';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-task-info',
  templateUrl: './task-info.component.html',
  styles: [
  ]
})
export class TaskInfoComponent implements OnInit, OnDestroy {

  id: number;
  constructor(private route: ActivatedRoute, public service: TaskService,
    public userService: UserService, private toastr: ToastrService) { }
  
  ngOnDestroy(): void {
    this.service.formData = new Task();
  }

  ngOnInit(): void {
    this.route.paramMap.pipe(switchMap(params => params.getAll('id')))
        .subscribe(data=> this.id = +data);
    this.service.formData.projectId = this.id;
  }

  onSubmit(form: NgForm){
    if(this.service.formData.id == 0 && this.userService.role === 'Manager')
      this.inserRecord(form);
    else if (this.service.formData.id != 0)
      this.updateRecord(form);
    else this.toastr.info('Select task to change', `Task wasn't updated`);
  }

  inserRecord(form: NgForm){
    this.service.postTask().subscribe(
      res => {
        this.toastr.info('Submitted succesfully', `Task '${form.value.name}' added`);
        this.resetForm(form);
        this.service.refreshListManager(this.id);
      },
      err => {
        this.toastr.error(err.error, "Task wasn't added")
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putTask().subscribe(
      res => {
        this.toastr.info('Submitted succesfully', `Task '${form.value.name}' updated`);
        this.resetForm(form);
        if (this.userService.role === 'Manager')
          this.service.refreshListManager(this.id);
        else this.service.refreshListUser(this.id);
      },
      err => {
        this.toastr.error(err.error, "Task wasn't updated")
      }
    );
  }

  resetForm(form:NgForm){
    let prId = this.service.formData.projectId;
    this.service.formData = new Task();
    this.service.formData.projectId = prId;
  }

}
