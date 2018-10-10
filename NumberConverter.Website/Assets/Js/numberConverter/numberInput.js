import React from 'react';

class NumberInput extends React.Component {
    constructor(props) {
        super(props);
        this.state = { number: '' };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ number: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        this.props.onSetNumber(this.state.number);
    }

    render() {
        return (
            <div className="number-converter__input-container">
                <form onSubmit={this.handleSubmit}>
                    <input className="number-converter__input" type="number" value={this.state.number} onChange={this.handleChange} />
                    <input className="number-converter__submit" type="submit" value="Convert" />
                </form>
            </div>
        )
    }
}

export default NumberInput;