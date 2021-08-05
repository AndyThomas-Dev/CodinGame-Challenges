

let lineArray: line[] = [];

class line {

    index: number;
    operation: string;
    arg1: string;
    arg2: string;
    value: number;

}

const N: number = parseInt(readline());


// populate line array
for (let i = 0; i < N; i++) {

    var inputs: string[] = readline().split(' ');

    let newLine: line = new line;
    newLine.index = i;
    newLine.operation = inputs[0];
    newLine.arg1 = inputs[1];
    newLine.arg2 = inputs[2];
    lineArray.push(newLine);

}


for (let i = 0; i < N; i++) {
    // console.log("XX", lineArray[i])

    let arg1Value: number = getValue(lineArray[i].arg1, i);
    let arg2Value: number = getValue(lineArray[i].arg2, i);

    if(lineArray[i].operation == 'VALUE'){
        lineArray[i].value = arg1Value;
    }

    if(lineArray[i].operation ==  'ADD'){
        // console.log("Adding", arg1Value, arg2Value)
        lineArray[i].value = (arg1Value + arg2Value);
    }

    if(lineArray[i].operation == 'SUB'){
        // console.log("SUBBING", arg1Value, arg2Value)
        lineArray[i].value = (arg1Value - arg2Value);
    }

    if(lineArray[i].operation == 'MULT'){
        lineArray[i].value = (arg1Value * arg2Value);
    }
}

for (let j = 0; j < N*10; j++) {
    for (let i = 0; i < N; i++) {

        if(!isNaN(lineArray[i].value)){
            continue;
        }

        let arg1Value: number = getValue(lineArray[i].arg1, i);
        let arg2Value: number = getValue(lineArray[i].arg2, i);

        if(lineArray[i].operation == 'VALUE'){
            lineArray[i].value = arg1Value;
            continue;
        }

        if(lineArray[i].operation ==  'ADD'){
            // console.log("Adding", arg1Value, arg2Value)
            lineArray[i].value = (arg1Value + arg2Value);
        }

        if(lineArray[i].operation == 'SUB'){
            lineArray[i].value = (arg1Value - arg2Value);
        }

        if(lineArray[i].operation == 'MULT'){
            lineArray[i].value = (arg1Value * arg2Value);
        }

    }
}

for (let i = 0; i < N; i++) {

    // Fix weird -0 multi issue
    if(lineArray[i].value == -0){
        console.log("0")
    }
    else{
        console.log(lineArray[i].value)
    }
    
}

function getValue(arg: string, i:number) {

    if(arg[0] == '_'){
        return 0;
    }

    if(arg[0] == '$'){
        let index = parseInt(arg.substring(1));

        if(index > lineArray[i].index){

            if(lineArray[index].operation == 'ADD'){
                return getValue(lineArray[index].arg1, index) + getValue(lineArray[index].arg2, index);
            }

            if(lineArray[index].operation == 'SUB'){
                return getValue(lineArray[index].arg1, index) - getValue(lineArray[index].arg2, index);
            }

            if(lineArray[index].operation == 'MULT'){

                return getValue(lineArray[index].arg1, index) * getValue(lineArray[index].arg2, index);
            }

        }

        return lineArray[index].value;
    }

    else{
        return parseInt(arg);
    }
}

