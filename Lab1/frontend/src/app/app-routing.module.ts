import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForbiddenComponent } from './components/help/forbidden/forbidden.component';
import { HomeComponent } from './components/home/home.component';
import { ProjectTasksComponent } from './components/project/project-tasks/project-tasks.component';
import { TaskInfoComponent } from './components/project/project-tasks/task-info/task-info.component';
import { ProjectUsersComponent } from './components/project/project-users/project-users.component';
import { AuthComponent } from './components/user/auth/auth.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { AuthGuard } from './helpers/auth/auth.guard';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path: 'user', component: AuthComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
  {path: 'project/:id/users', component: ProjectUsersComponent,canActivate:[AuthGuard],data :{permittedRoles:['Manager']}},
  {path: 'project/:id/tasks', component: ProjectTasksComponent,canActivate:[AuthGuard],data :{permittedRoles:['User','Manager']}},
  {path: 'project/:id/tasks', component: TaskInfoComponent,canActivate:[AuthGuard],data :{permittedRoles:['User','Manager']}},
  {path:'forbidden',component:ForbiddenComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
