import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { AuthComponent } from './components/user/auth/auth.component';
import { HomeComponent } from './components/home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserService } from './shared/user/user.service';
import { AuthInterceptor } from './helpers/auth/auth.interceptor';
import { ForbiddenComponent } from './components/help/forbidden/forbidden.component';
import { NavComponent } from './components/help/nav/nav.component';
import { ProjectInfoComponent } from './components/project/project-info/project-info.component';
import { ProjectComponent } from './components/project/project.component';
import { SortDirective } from './helpers/util/sort.directive';
import { ProjectUsersComponent } from './components/project/project-users/project-users.component';
import { ProjectTasksComponent } from './components/project/project-tasks/project-tasks.component';
import { TaskInfoComponent } from './components/project/project-tasks/task-info/task-info.component';
import { UserRoleComponent } from './components/user/admin-panel/user-role/user-role.component';
import { AdminPanelComponent } from './components/user/admin-panel/admin-panel.component';
import { CustomFilterPipe } from './custom-filter-pipe.pipe';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    AuthComponent,
    HomeComponent,
    AdminPanelComponent,
    ForbiddenComponent,
    NavComponent,
    ProjectInfoComponent,
    ProjectComponent,
    SortDirective,
    ProjectUsersComponent,
    ProjectTasksComponent,
    TaskInfoComponent,
    UserRoleComponent,
    CustomFilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    FormsModule
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
