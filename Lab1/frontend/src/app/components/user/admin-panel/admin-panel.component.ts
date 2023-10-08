import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserRole } from 'src/app/shared/user/user-role.model';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styles: [
  ]
})

export class AdminPanelComponent implements OnInit, OnDestroy {
  serach: string;

  constructor(public service:UserService, private toastr:ToastrService) { }
  
  ngOnDestroy(): void {
    this.service.listOfUsersAndManagers.length = 0;
  }

  ngOnInit(): void {
    this.service.usersAndManagers();
    this.serach ='';
  }

  onDelete(user: UserRole){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.removeUser(user.id)
      .subscribe(
       res=>{
          this.toastr.error("Deleted successfully", `User '${user.fullName}' deleted`)
          this.service.userRoleFormData = new UserRole();
          this.service.usersAndManagers();
       },
       err => {
        this.toastr.error(err.error, "User wasn't deleted")
        }
      )
    }
  }

  populateForm(selectedRecord:UserRole){
    this.service.userRoleFormData =  Object.assign({}, selectedRecord);
  }

}
