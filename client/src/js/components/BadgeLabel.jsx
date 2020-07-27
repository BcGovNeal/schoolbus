import React from 'react';
import PropTypes from 'prop-types';
import { Badge } from 'react-bootstrap';

class BadgeLabel extends React.Component {
  static propTypes = {
    bsClass: PropTypes.string,
    variant: PropTypes.string,
    className: PropTypes.string,
    children: PropTypes.node,
  };

  render() {
    return (
      <Badge
        bsClass={this.props.bsClass}
        variant={this.props.variant}
        className={`badge-label ${this.props.className || ''}`}
      >
        {this.props.children}
      </Badge>
    );
  }
}

export default BadgeLabel;
