import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login.componenet';
import { ListActivitiesComponent } from './listactivities.component';
import { AddActivityComponent } from './addactivity.component';
import { AdminComponent } from './admin.component';
import { AuthGuard } from './auth-guard';
import { ContactComponent } from './contact.component';
import { AdminListComponent } from './adminlist.component';


const routes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'nav',component:AdminListComponent,canActivate: [AuthGuard]},
  {path:'list',component:ListActivitiesComponent},
  {path:'addactivity',component:AddActivityComponent},
  {path:'contact',component:ContactComponent},
  {path:'Admins', component: AdminComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
