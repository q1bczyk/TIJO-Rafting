import { Directive, OnInit } from '@angular/core';
import { CrudService } from '../services/crud.service';
import { ApiManager } from '../api/api-manager';
import { ApiSuccessResponse } from '../types/api-success-response.type';
import { ConfirmationModalService } from '../../shared/services/confiramtion-modal.service';
import { ToastService } from '../../shared/services/ui/toasts/toast.service';

@Directive({
  standalone: true
})
export class BaseReadDirective<TGet, TService extends CrudService<TGet, any, any>> implements OnInit
{
  constructor(
    protected service : TService, 
    public apiManager : ApiManager<TGet[]>, 
    public confirmationModalService : ConfirmationModalService,
    protected apiDeleteManager : ApiManager<ApiSuccessResponse>,
    private toastService : ToastService
    )
    {}

  ngOnInit(): void {
    this.apiManager.exeApiRequest(this.service.fetchAll());
  }

  deleteApiRequest(dataId : string) : void{
    this.apiDeleteManager.exeApiRequest(this.service.delete(dataId), () => this.onSuccessDelete());
  }

  private onSuccessDelete() : void {
    this.apiManager.exeApiRequest(this.service.fetchAll());
    this.toastService.showToast('Pomyślnie usunięto dane', 'success');

  }
}
