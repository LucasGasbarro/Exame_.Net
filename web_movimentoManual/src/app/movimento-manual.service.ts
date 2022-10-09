import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MovimentoManualService {

  constructor(private http:HttpClient) { }

  getMovimentoManual(){
    return this.http.get("https://localhost:5001/v1/movimentosManual");

  }

  getProduto(){
    return this.http.get("https://localhost:5001/v1/produto");
  }

  getCosif(id:string){
    return this.http.get(`https://localhost:5001/v1/produtocosif/Produto/${id}`);
  }

  postMovimento(movimento:any){
    return this.http.post("https://localhost:5001/v1/movimentosManual", movimento)
  }
}
