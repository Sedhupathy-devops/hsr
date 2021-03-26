import React from 'react';
import ReactDOM from 'react-dom';
import Keypad from './Keypad';
import Enzyme, { shallow } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({ adapter: new Adapter() });

const handleKeypadClick = jest.fn(({ target }) => target.value);
const handleOperatorClick = jest.fn(({ target }) => target.value);
const handleEqualsClick = jest.fn(({ target }) => target.value);
const handleClearClick = jest.fn(({ target }) => target.value);

it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render(<Keypad />, div);
    ReactDOM.unmountComponentAtNode(div);
});

it('should call handleKeypadClick', () => {
    const keypad = shallow(<Keypad onEqualsClick={handleEqualsClick}
        onClearClick={handleClearClick}
        onKeyClick={handleKeypadClick}
        onOperatorClick={handleOperatorClick} />);

    keypad.find({ value: '2' }).simulate('click', { target: { value: 2 } });

    expect(handleKeypadClick).toBeCalledWith({ target: { value: 2 } });

});
it('should call handleEqualsClick', () => {
    const keypad = shallow(<Keypad onEqualsClick={handleEqualsClick}
        onClearClick={handleClearClick}
        onKeyClick={handleKeypadClick}
        onOperatorClick={handleOperatorClick} />);

    keypad.find({ value: '=' }).simulate('click', { target: { value: '=' } });
    expect(handleEqualsClick).toBeCalledWith({ target: { value: '=' } })
});

it('should call handleOperatorClick', () => {
    const keypad = shallow(<Keypad onEqualsClick={handleEqualsClick}
        onClearClick={handleClearClick}
        onKeyClick={handleKeypadClick}
        onOperatorClick={handleOperatorClick} />);

    keypad.find({ value: '+' }).simulate('click', { target: { value: '+' } });
    expect(handleOperatorClick).toBeCalledWith({ target: { value: '+' } })
});

it('should call handleClearClick', () => {
    const keypad = shallow(<Keypad onEqualsClick={handleEqualsClick}
        onClearClick={handleClearClick}
        onKeyClick={handleKeypadClick}
        onOperatorClick={handleOperatorClick} />);

    keypad.find({ value: 'Clear' }).simulate('click', { target: { value: 'Clear' } });
    expect(handleClearClick).toBeCalledWith({ target: { value: 'Clear' } })
});