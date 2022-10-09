import { Component } from '@angular/core';
import { MovimentoManualService } from './movimento-manual.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  movimentos :any = [];
  produtos :any = [];
  cosifs :any = [];

  movimentoForm = new FormGroup({
    mes: new FormControl(''),
    ano: new FormControl(''),
    produto: new FormControl(''),
    cosif: new FormControl(''),
    valor: new FormControl(''),
    descricao: new FormControl('')
  })

  constructor(private movimentoService: MovimentoManualService){

  }

  ngOnInit(){
    this.getMovimento()
    this.movimentoService.getProduto().subscribe(res => {
      this.produtos = res;
    })
    this.movimentoForm.disable();
  }

  getMovimento()
  {
    this.movimentoService.getMovimentoManual().subscribe(res => {
      this.movimentos = res;
    })
  }
  
  getProdutoCosif(evento:Event|null){
    const produtoID = (evento?.target as any).value

    if (produtoID){
      this.movimentoService.getCosif(produtoID).subscribe(res => {
        this.cosifs = res;
      })
    }
    else{
      this.cosifs = []
    }
  }

  createMovimentoManual(){
    const {mes,ano, produto, cosif, valor, descricao} = this.movimentoForm.value;
    const movimento = {
      "DAT_MES": mes && parseInt(mes),
      "DAT_ANO": ano && parseInt(ano),
      "COD_PRODUTO": produto,
      "COD_COSIF": cosif,
      "DES_DESCRICAO": descricao,
      "COD_USUARIO": "TESTE",
      "VAL_VALOR": valor && parseFloat(valor)
    }
    this.movimentoService.postMovimento(movimento).subscribe(res => {
      this.movimentoForm.reset();
      this.movimentoForm.disable();
      this.getMovimento();
      
    })
  }

  newMovimento(){
    this.movimentoForm.enable();
  }
  
}