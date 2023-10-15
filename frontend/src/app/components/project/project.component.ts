import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Project } from 'src/app/shared/project/project.model';
import { ProjectService } from 'src/app/shared/project/project.service';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styles: [
  ]
})
export class ProjectComponent implements OnInit {
  
  serach:string;
  constructor(public service:ProjectService, public userService:UserService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.serach ='';
  }

  populateForm(selectedRecord:Project){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(project: Project){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteProject(project.id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.service.formData = new Project();
         this.toastr.error("Deleted successfully", `Project '${project.name}' deleted`)
       },
       err => {
        this.toastr.error(err.error, "Project wasn't deleted")
        }
      )
    }
  }
}