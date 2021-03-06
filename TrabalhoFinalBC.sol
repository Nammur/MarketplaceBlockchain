pragma  solidity  ^0.7.0;

struct Item{
	uint ataque;
	uint defesa;
	uint acerto;
	uint vida;
	uint raridade;
	uint tipo;
	uint habilidade;
	bool avenda;
	uint preco;
	address dono;
}

contract TrabalhoFinalBlockchain {
    
    address payable private owner;
	mapping (address=>Item) private itens;
	mapping (address=>uint) private balances;
	
    
    constructor() payable {
        owner = payable(msg.sender);
		balances[address(this)] += msg.value;
    }
    
    modifier onlyOwner {
        require(msg.sender == owner, "Somente o dono do contrato pode executar essa funcao!");
        _;
    }
	function CriarItem (uint ataque, uint defesa, uint acerto, uint vida, uint raridade, uint tipo, uint habilidade) public onlyOwner returns(address){
		address endereco = address(bytes20(sha256(abi.encodePacked(msg.sender, block.timestamp))));
		itens[endereco] =  Item(ataque,defesa,acerto,vida,raridade,tipo,habilidade,false,0,address(0));
		return endereco;
	}

	function GetItem(address endereco) public view returns(uint, uint, uint, uint, uint, uint, uint, bool, uint, address){
		Item memory i = itens[endereco];
		return(i.ataque, i.defesa, i.acerto, i.vida, i.raridade, i.tipo, i.habilidade, i.avenda, i.preco, i.dono);
	}

	function ComprarItem(address endereco) payable public{
		Item storage item = itens[endereco];
		address antigoDono = item.dono;
		require(item.preco == msg.value, "O valor da transferencia nao corresponde.");
		require(antigoDono != msg.sender, "Nao pode comprar seu prorio item.");
		require(item.avenda == true, "Esse item nao esta a venda.");
		require(msg.sender.balance >= item.preco, "Saldo insuficiente para a compra do item.");

		item.dono = msg.sender;
		item.preco = 0;
		item.avenda = false;
		itens[endereco] = item;

		balances[address(this)] += msg.value / 10;
		balances[antigoDono] += msg.value /10 * 9;
	}

	function AdicionarFundos() onlyOwner payable public{
		require(msg.value > 0, "Adicione fundos a transacao.");
		balances[address(this)] += msg.value;
	}

	function ColocarItemAVenda(address endereco, uint valor) public {
		Item memory item = itens[endereco];
		require(item.dono == msg.sender, "Apenas o dono do item pode coloca-lo a venda");

		item.avenda = true;
		item.preco = valor;

		itens[endereco] = item;
	}

	function GetSaldoContrato() onlyOwner public view returns(uint) {
		uint saldo = balances[address(this)];
		return saldo;
	}

	function SacarTudoContrato() onlyOwner public{
		msg.sender.transfer(balances[address(this)]);
		balances[address(this)] = 0;
	}

	function SacarSaldo() public {
		msg.sender.transfer(balances[msg.sender]);
		balances[msg.sender] = 0;
	}

	function AtribuirNovoDono(address item, address novoDono) onlyOwner public{
		itens[item].dono = novoDono;
	}

	function VerSaldo() view public returns(uint){	
		uint saldo = balances[msg.sender]; 
		return saldo;
	}

	function destroy() public onlyOwner {
        selfdestruct(owner);
    }
}
