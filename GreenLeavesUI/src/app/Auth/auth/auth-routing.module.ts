import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from '../Components/register/register.component';

const routes: Routes = [
  {path: '',
  component: RegisterComponent,
  children: [
    {
      path: '**',
      redirectTo: 'register'
    }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
