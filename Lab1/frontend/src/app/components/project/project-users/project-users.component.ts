import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { switchMap } from 'rxjs/operators';
import { ProjectService } from 'src/app/shared/project/project.service';
import { UserToProject } from 'src/app/shared/user/user-to-project.model';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-project-users',
  templateUrl: './project-users.component.html',
  styles: [
  ]
})
export class ProjectUsersComponent implements OnInit {
  id: number;
  serach:string;
  
  constructor(private route: ActivatedRoute, private toastr:ToastrService,
    public userService: UserService, public projectService: ProjectService) {
   }

  ngOnInit(): void {
    this.route.paramMap.pipe(switchMap(params => params.getAll('id')))
        .subscribe(data=> this.id = +data);
    this.userService.usersInProject(this.id);
    this.serach ='';
  }

  onDelete(userId: number){
    if (confirm('Are you sure to delete this user?'))
    {
      this.projectService.deleteUserFromProject(new UserToProject(this.id, userId))
      .subscribe(
       res=>{
         this.userService.usersInProject(this.id);
         this.toastr.error("Deleted successfully", `User deleted`)
       },
       err => {
        this.toastr.error(err.error, "User wasn't deleted")
        }
      )
    }
  }

  onAdd(userId: number){
    if (confirm('Are you sure to add this user?'))
    {
      this.projectService.addUserToProject(new UserToProject(this.id, userId))
      .subscribe(
       res=>{
         this.userService.usersInProject(this.id);
         this.toastr.success("Added successfully", `User added`)
       },
       err => {
        this.toastr.error(err.error, "User wasn't added")
        }
      )
    }
  }
}
