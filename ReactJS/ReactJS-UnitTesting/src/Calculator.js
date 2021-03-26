import React, { useState } from 'react';
import Keypad from "./Keypad";

function Calculator() {
    const [result, setResult] = useState(0);
    const [operator, setOperator] = useState("");
    const [operand2, setOperand2] = useState(0);
    const [operand1, setOperand1] = useState(0);
    const handleChange = ({ target }) => {
        setResult(target.value);
    }
    const handleEqualsClick = ({ target }) => {
        if (operand1 && operand2 && operator) {
            switch (operator) {
                case "/": setResult(operand1 / operand2);
                    setOperand1(operand1 / operand2);
                    break;
                case "X": setResult(operand1 * operand2);
                    setOperand1(operand1 * operand2);
                    break;
                case "+": setResult(operand1 + operand2);
                    setOperand1(operand1 + operand2);
                    break;
                case "-": setResult(operand1 - operand2);
                    setOperand1(operand1 - operand2);
                    break;
                default:
                    break;
            }
            setOperand2(0);
            setOperator("");
        }
    }
    const handleClearClick = ({ target }) => {
        setResult(0);
        setOperator("");
        setOperand2(0);
        setOperand1(0);
    }
    const handleKeypadClick = ({ target }) => {
        if (!operator) {
            setOperand1(+(operand1 + "" + target.value));
            setResult(+(operand1 + "" + target.value));
        } else {
            setOperand2(+(operand2 + "" + target.value));
            setResult(+(operand2 + "" + target.value));
        }
    }
    const handleOperatorClick = ({ target }) => {
        if (operator) {
            handleEqualsClick({ target });
        }
        setOperator(target.value);
        setOperand2(0);
    }
    return <div className="container-fluid">
        <div className="row">
            <div className="col-sm-2 offset-sm-5">
                <input type="text" className="form-control" readOnly onChange={handleChange} value={result} />
            </div>
        </div>
        <div className="row">
            <div className="col-sm-2 offset-sm-5">
                <Keypad onEqualsClick={handleEqualsClick}
                    onClearClick={handleClearClick}
                    onKeyClick={handleKeypadClick}
                    onOperatorClick={handleOperatorClick} />
            </div>
        </div>
    </div>;
}
export default Calculator;