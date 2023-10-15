import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserRole } from 'src/app/shared/user/user-role.model';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-user-role',
  templateUrl: './user-role.component.html',
  styles: [
  ]
})
export class UserRoleComponent implements OnInit {

  constructor(public service:UserService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  updateRecord(form:NgForm){
    this.service.changeUserRole().subscribe(
      res => {
        this.toastr.info('Submitted succesfully', `User '${form.value.fullName}' updated`);
        this.resetForm(form);
        this.service.usersAndManagers();
      },
      err => {
        this.toastr.error(err.error, "User role wasn't updated")
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.userRoleFormData = new UserRole();
  }
}
